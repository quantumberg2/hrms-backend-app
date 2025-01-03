﻿using HRMS_Application.BusinessLogic.Interface;
using HRMS_Application.DTO;
using HRMS_Application.Middleware.Exceptions;
using HRMS_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace HRMS_Application.BusinessLogic.Implements
{
    public class CompanyDetailsImp : ICompanyDetails
    {
        private readonly HRMSContext _context;
        private readonly IAzureOperations _azureOperations;
        public CompanyDetailsImp(HRMSContext context, IAzureOperations azureOperations)
        {
            _context = context;
            _azureOperations = azureOperations;
        }
        public bool deleteCompanyDetails(int id)
        {
            var result = (from row in _context.CompanyDetails
                          where row.Id == id
                          select row).SingleOrDefault();
            if (result != null)
            {
                _context.CompanyDetails.Remove(result);
                _context.SaveChanges();
                return true;
            }
            else
            {
                throw new NotFoundException($"Could not delete CompanyDetails of {id}");
            }
        }

        public List<CompanyDetail> GetAllCompanyDetails()
        {
            var result = (from row in _context.CompanyDetails
                          where  row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public List<CompanyDetail> GetCompanyDetailstById(int id)
        {
            var result = (from row in _context.CompanyDetails
                          where row.Id == id && row.IsActive == 1
                          select row).ToList();
            return result;
        }

        public List<ComanyLogoDTO> GetCompanyDetailstByCompanyId(int CompanyId)
        {
            var info = (from row in _context.CompanyDetails
                        where row.RequestedCompanyId == CompanyId && row.IsActive == 1
                        select new ComanyLogoDTO
                        {
                            CompanyName = row.Name, 
                            CompanyLogo = row.CompanyLogo 
                        }).ToList();

            return info;
        }
        public string InsertCompanyDetails(CompanyDetailsDTO companyDetail, int companyId)
        {
            string logoUrl = _azureOperations.StoreFilesInAzure(companyDetail.CompanyLogo, "hrms-profile-pics");

            CompanyDetail objCompanyDetail = new CompanyDetail
            {
                Name = companyDetail.Name,
                Address = companyDetail.Address,
                States = companyDetail.States,
                Country = companyDetail.Country,
                Currency = companyDetail.Currency,
                EsiNo = companyDetail.EsiNo,
                GstNo = companyDetail.GstNo,
                Industry = companyDetail.Industry,
                Facebook = companyDetail.Facebook,
                LinkedIn = companyDetail.LinkedIn,
                Twitter = companyDetail.Twitter,
                PanNo = companyDetail.PfNo,
                PfNo = companyDetail.PfNo,
                RegistrationNo = companyDetail.RegistrationNo,
                TanNo =  companyDetail.TanNo, 
                TimeZone = companyDetail.TimeZone,   
                IsActive = 1,
                RequestedCompanyId = companyId,
             //   RequestedCompanyId = companyDetail.companyDetail.RequestedCompanyId,
                CompanyLogo = logoUrl

            };

            if (objCompanyDetail !=null)
            {
                _context.CompanyDetails.Add(objCompanyDetail);
                _context.SaveChanges();

                return "Company Details inserted successfully";
            }
            return "Failed to insert company details";

            
        }

        public bool SoftDelete(int id, short isActive)
        {
            var res = (from row in _context.CompanyDetails
                       where row.Id == id
                       select row).FirstOrDefault();
            if(res!=null)
            {
                res.IsActive = isActive;
                _context.CompanyDetails.Update(res);
                _context.SaveChanges();
                return true;

            }
            return false;
        }



        public string updateCompanyLogo(IFormFile companyLogo, int companyId)
        {
            // Store the company logo in Azure and get the URL
            string logoUrl = _azureOperations.StoreFilesInAzure(companyLogo, "hrms-profile-pics");

            // Find the company details in the database
            var res = (from row in _context.CompanyDetails
                       where row.RequestedCompanyId == companyId && row.IsActive == 1
                       select row).FirstOrDefault();

            // Update the company logo URL if the company exists
            if (res != null)
            {
                res.CompanyLogo = logoUrl;
                _context.SaveChanges();
                return logoUrl;
            }

            return null;
        }

    }
}
