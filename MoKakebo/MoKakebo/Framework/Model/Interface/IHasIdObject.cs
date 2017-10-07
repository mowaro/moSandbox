using System;

namespace MoKakebo.Framework.Model.Interface {
    public interface IHasIdObject : IEquatable<IHasIdObject> {
        long id { get; }
        bool Equals(long id);
    }
}
