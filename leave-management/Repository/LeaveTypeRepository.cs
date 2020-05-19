﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using leave_management.Contracts;
using leave_management.Data;

namespace leave_management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<LeaveType> FindAll()
        {
            // return _db.LeaveTypes.ToList();
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveTypes = _db.LeaveTypes.Find(id);
            return leaveTypes;
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveTypes.Any(q => q.Id == id);
            return exists;
        }

        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0; //(if changes > 0, return)
        }

        public ICollection<LeaveType> GetEmployeesLeaveType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
