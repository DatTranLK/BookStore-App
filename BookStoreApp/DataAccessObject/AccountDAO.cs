using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        private static readonly object instanceLock = new object();
        BookStoreDBContext _dBContext = new BookStoreDBContext();
        public AccountDAO()
        {

        }
        public static AccountDAO Instance 
        {
            get 
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    { 
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }
        public Account CheckLogin(string username, string password)
        {
            try
            {
                if(!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
                {
                    username = username.Trim();
                    password = password.Trim();
                    var account = _dBContext.Accounts.FirstOrDefault(x => x.Username == username && x.Password == password);
                    if (account != null)
                    {
                        return account;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Register(Account account)
        {
            try
            {
                account.RoleId = 4;
                account.IsActive = true;
                _dBContext.Accounts.Add(account);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Account GetAccountByUsername(string username)
        {
            try
            {
                var acc = _dBContext.Accounts.FirstOrDefault(x => x.Username == username);
                if (acc != null)
                {
                    return acc;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<Account> GetAccounts()
        {
            try
            {
                var accounts = _dBContext.Accounts
                    .Include(x => x.Role)
                    .Include(x => x.Store)
                    .OrderByDescending(x => x.Id)
                    .ToList();
                if (accounts != null)
                {
                    return accounts;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public Account GetAccountById(int id)
        {
            try
            {
                var acc = _dBContext.Accounts
                    .Include(x => x.Role)
                    .Include(x => x.Store)
                    .FirstOrDefault(x => x.Id == id);
                if (acc != null)
                {
                    return acc;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void RemoveAccount(int id)
        {
            try
            {
                var acc = _dBContext.Accounts.FirstOrDefault(x => x.Id == id);
                if (acc != null)
                {
                    if (acc.IsActive == true)
                    {
                        acc.IsActive = false;
                        _dBContext.SaveChanges();
                    }
                    else if(acc.IsActive == false)
                    {
                        acc.IsActive = true;
                        _dBContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CreateNewAccount(Account account)
        {
            try
            {
                account.IsActive = true;
                _dBContext.Accounts.Add(account);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void UpdateAccount(Account account)
        {
            try
            {
                account.IsActive = true;
                _dBContext.ChangeTracker.Clear();
                _dBContext.Entry<Account>(account).State = EntityState.Modified;
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
