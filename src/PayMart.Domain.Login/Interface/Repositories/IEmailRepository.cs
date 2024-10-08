﻿using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Interface.DataBase;

namespace PayMart.Domain.Login.Interface.Repositories;

public interface IEmailRepository : ICommit
{
    Task<LoginUser?> VerifyEmail(string email);
}
