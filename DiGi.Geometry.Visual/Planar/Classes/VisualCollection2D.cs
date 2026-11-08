using DiGi.Geometry.Visual.Core.Classes;
using DiGi.Geometry.Visual.Planar.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DiGi.Geometry.Visual.Planar.Classes
{
    /// <summary>
    /// Represents a collection of 2D visual elements.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1010:Generic interface should also be implemented", Justification = "Serialized visual type: an added IEnumerable<T> would change how the DiGi serializer writes it.")]
    public class VisualCollection2D : VisualCollection<IVisual2D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualCollection2D"/> class using an enumerable of 2D visuals.
        /// </summary>
        /// <param name="visual2Ds">The collection of 2D visual elements to initialize with.</param>
        public VisualCollection2D(IEnumerable<IVisual2D>? visual2Ds)
            : base(visual2Ds)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualCollection2D"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the collection data.</param>
        public VisualCollection2D(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualCollection2D"/> class using another <see cref="VisualCollection2D"/> object.
        /// </summary>
        /// <param name="visualCollection2D">The source collection to copy from.</param>
        public VisualCollection2D(VisualCollection2D? visualCollection2D)
            : base(visualCollection2D)
        {
        }
    }
}