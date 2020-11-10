using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ent = DAL.EF;
using data = DO.Objects;

namespace Maps
{
    public class Maps
    {
        public static void CreateMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ent.client, data.clients>();
                cfg.CreateMap<data.clients, ent.client>();
            });
        }
    }
}
