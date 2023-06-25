using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SnnbDB.Models;
using SnnbDB.Rest;

namespace SnnbDB.ModelExt;
internal class rtStatus
{
    public List<MSpectralNetGroup> SpecNetGroups { get; set; }
    public List<MModule> Modules { get; set; }
}
