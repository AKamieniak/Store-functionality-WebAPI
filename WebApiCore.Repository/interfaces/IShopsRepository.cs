using System;
using System.Collections.Generic;
using System.Text;
using WebApiCore.Models;

namespace WebApiCore.Repository
{
    public interface IShopsRepository
    {
        //---interface of ShopsRepository methods---

        List<Shop> GetShopsAll();
        List<Shop> GetShopsByCity(string city);
        void AddShop(Shop shop);
        void DeleteShop(int id);
        int GetLastIndexOfShop();
    }
}
