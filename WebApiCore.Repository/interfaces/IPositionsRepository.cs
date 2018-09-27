using System;
using System.Collections.Generic;
using System.Text;
using WebApiCore.Models;

namespace WebApiCore.Repository
{
    public interface IPositionsRepository
    {
        //---interface of PositionsRepository methods---

        List<Position> GetPositionsAll();
        void AddPosition(Position position);
        void DeletePosition(int id);
        int GetLastIndexOfPosition();
    }
}
