using System.Collections;

namespace DiGi.Geometry.Visual.Core.Interfaces
{
    /// <summary>
    /// Represents a strongly-typed collection of visual elements.
    /// </summary>
    /// <typeparam name="T">The type of visual elements in the collection, which must implement <see cref="IVisual"/>.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1010:Generic interface should also be implemented", Justification = "Serialized visual types: an added IEnumerable<T> would change how the DiGi serializer writes them.")]
    public interface IVisualCollection<T> : IVisualCollection where T : IVisual
    {
    }

    /// <summary>
    /// Represents a collection of visual elements.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1010:Generic interface should also be implemented", Justification = "Non-generic base of IVisualCollection<T>; serialized visual types.")]
    public interface IVisualCollection : IVisual, IEnumerable
    {
    }
}