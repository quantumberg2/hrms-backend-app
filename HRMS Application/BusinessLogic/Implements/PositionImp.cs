﻿using HRMS_Application.Authorization;
using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.BusinessLogics.Implements;
using HRMS_Application.BusinessLogics.Interface;
using HRMS_Application.Middleware.Exceptions;
using HRMS_Application.Models;
using System.IdentityModel.Tokens.Jwt;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class PositionImp : IPosition
    {
        private readonly HRMSContext _hrmsContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtUtils _jwtUtils;
        private List<string>? dToken;
        private int? _decodedToken;
        public PositionImp(HRMSContext hrmsContext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
        {
            _hrmsContext = hrmsContext;
            _httpContextAccessor = httpContextAccessor;
            _jwtUtils = jwtUtils;
            
        }
         private void DecodeToken()
         {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
             if (string.IsNullOrEmpty(token))
             {
                dToken = null;
             }
             else
             {
              var userId = _jwtUtils.ValidateJwtToken(token);
              if (userId.HasValue)
              {
                var userDetails = _hrmsContext.EmployeeCredentials.FirstOrDefault(e => e.Id == userId.Value);
                if (userDetails != null)
                {
                    _decodedToken = userDetails.Id;
                    dToken = userDetails.UserRolesJs.Select(ur => ur.Roles.Name).ToList(); // Assuming you want role names
                }
                else
                {
                    // Handle the case where the user is not found in the database
                    dToken = null;
                }
            }
        }
    }
        public async Task<bool> deletePosition(int id)
        {
            DecodeToken();
            var result = (from row in _hrmsContext.Positions
                          where row.Id == id
                          select row).SingleOrDefault();
            _hrmsContext.Positions.Remove(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return true;
        }

      

        public List<Position> GetPositions()
        {
            var result = (from row in _hrmsContext.Positions
                          where row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public async Task<string> InsertPositions(Position position)
        {
            try
            {
                DecodeToken();
               // position.RequestedCompanyId = companyID;
                await _hrmsContext.Positions.AddAsync(position);
                var result = await _hrmsContext.SaveChangesAsync(_decodedToken);
                if (result != 0)
                {
                    return "new Position inserted successfully";

                }

                else
                {
                    throw new DatabaseOperationException("Failed to insert Position data");
                }
            }
            catch(Exception) 
            {
                throw new DatabaseOperationException("Failed to insert Position data");
            }
        }

        public async Task<Position> updateposition(int id, string? name, int? requestedcompanyId)
        {
            DecodeToken();
            var result = _hrmsContext.Positions.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                // Handle the case where the user with the specified id doesn't exist
                return null;
            }
            result.Name = name;
            result.RequestedCompanyId = requestedcompanyId;
            _hrmsContext.Positions.Update(result);
            await _hrmsContext.SaveChangesAsync(_decodedToken);
            return result;
        }

        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _hrmsContext.Positions
                       where row.Id == id
                       select row).FirstOrDefault();
            if (res != null)
            {
                res.IsActive = isActive;
                _hrmsContext.Positions.Update(res);
                _hrmsContext.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
