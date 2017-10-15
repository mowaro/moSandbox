using System;

namespace MoKakebo.Framework.Model.Interface {
    public interface IHasId : IEquatable<IHasId> {
        long Id { get; }
    }
}
