﻿using Callboard.App.General.Entities;
using System.Collections.Generic;

namespace Callboard.App.Business.Providers.Main
{
    public interface IKindProvider : IEntityProvider<Kind>
    {
        IReadOnlyCollection<Kind> GetKinds();
    }
}