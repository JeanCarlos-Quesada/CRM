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
                cfg.CreateMap<ent.client, data.client>();
                cfg.CreateMap<data.client, ent.client>();

                cfg.CreateMap<ent.employee, data.employee>();
                cfg.CreateMap<data.employee, ent.employee>();
            });
        }
    }
}
