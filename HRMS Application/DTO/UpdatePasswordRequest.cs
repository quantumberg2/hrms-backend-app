﻿namespace HRMS_Application.DTO
{
    public class UpdatePasswordRequest
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
