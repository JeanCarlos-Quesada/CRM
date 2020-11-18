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

                cfg.CreateMap<ent.user, data.user>();
                cfg.CreateMap<data.user, ent.user>();

                cfg.CreateMap<ent.users_X_rols, data.user_x_rols>();
                cfg.CreateMap<data.user_x_rols, ent.users_X_rols>();

                cfg.CreateMap<ent.rol, data.rol>();
                cfg.CreateMap<data.rol, ent.rol>();

                cfg.CreateMap<ent.key, data.key>();
                cfg.CreateMap<data.key, ent.key>();

                cfg.CreateMap<ent.category, data.category>();
                cfg.CreateMap<data.category, ent.category>();

                cfg.CreateMap<ent.product, data.product>();
                cfg.CreateMap<data.product, ent.product>();
            });
        }
    }
}
