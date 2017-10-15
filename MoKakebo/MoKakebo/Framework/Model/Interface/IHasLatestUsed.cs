using System;

namespace MoKakebo.Framework.Model.Interface {
    public interface IHasLatestUsed {
        DateTime LatestUsed { get; }
    }
}
