﻿using System;
using System.Linq;
using System.Xml.Linq;
using FEFTwiddler.Extensions;

namespace FEFTwiddler.Data
{
    public class ClassDatabase : BaseDatabase
    {
        public ClassDatabase(Enums.Language language) : base(language)
        {
            _data = XElement.Parse(Properties.Resources.Data_Classes);
        }

        public Class GetByID(Enums.Class classId)
        {
            var row = _data
                .Elements("class")
                .Where((x) => x.Attribute("id").Value == ((byte)classId).ToString())
                .First();

            var displayName = GetDisplayName(row);
            var baseStats = row.Elements("baseStats").First();

            return new Class
            {
                ClassID = (Enums.Class)row.GetAttribute<byte>("id"),
                DisplayName = displayName,
                Base_HP = baseStats.GetAttribute<byte>("hp"),
                Base_Str = baseStats.GetAttribute<byte>("str"),
                Base_Mag = baseStats.GetAttribute<byte>("mag"),
                Base_Skl = baseStats.GetAttribute<byte>("skl"),
                Base_Spd = baseStats.GetAttribute<byte>("spd"),
                Base_Lck = baseStats.GetAttribute<byte>("lck"),
                Base_Def = baseStats.GetAttribute<byte>("def"),
                Base_Res = baseStats.GetAttribute<byte>("res")
            };
        }
    }
}
