using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

using NPOI.HPSF;

using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Data
{

	public sealed class SkillTable : DataTable<Skill3>
	{
		readonly Dictionary<int, Dictionary<byte, Lazy<Skill3>>> Relation = new();

		protected override void LoadCache(XElement xElement, int CurID, Lazy<Skill3> data)
		{
			//临时获取方法
			if (!byte.TryParse(xElement.Attribute("variation-id")?.Value, out byte VariationId)) VariationId = 1;

			if (!Relation.ContainsKey(CurID)) Relation[CurID] = new();
			Relation[CurID][VariationId] = data;
		}

		public Skill3 GetInfo(int Id, byte VariationId)
		{
			if (!this.HasData) this.Load();

			if (this.Relation.ContainsKey(Id) && this.Relation[Id].ContainsKey(VariationId))
				return this.Relation[Id][VariationId].Value;

			return null;
		}
	}
}