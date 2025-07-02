using System.Collections.Generic;

namespace Quantaventis.Trading.Shared.Infrastructure.Modules;

internal record ModuleInfo(string Name, IEnumerable<string> Policies);
