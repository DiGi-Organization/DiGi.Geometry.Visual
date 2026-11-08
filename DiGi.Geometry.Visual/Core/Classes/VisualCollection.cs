using DiGi.Core.Classes;
using DiGi.Geometry.Visual.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Geometry.Visual.Core.Classes
{
    /// <summary>
    /// Represents an abstract base class for a collection of visual elements.
    /// </summary>
    /// <typeparam name="T">The type of visual elements contained in the collection, which must implement <see cref="IVisual"/>.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1010:Generic interface should also be implemented", Justification = "Serialized visual type: an added IEnumerable<T> would change how the DiGi serializer writes it.")]
    public abstract class VisualCollection<T> : Visual, IVisualCollection<T> where T : IVisual
    {
        [JsonIgnore]
        private readonly Dictionary<GuidReference, T> dictionary = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualCollection{T}"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the collection data.</param>
        public VisualCollection(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualCollection{T}"/> class by copying another visual collection.
        /// </summary>
        /// <param name="visualCollection">The source visual collection to copy from.</param>
        public VisualCollection(VisualCollection<T>? visualCollection)
            : base(visualCollection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualCollection{T}"/> class with a specified set of visuals.
        /// </summary>
        /// <param name="visuals">The initial collection of visual elements.</param>
        public VisualCollection(IEnumerable<T>? visuals)
            : base()
        {
            Values = visuals;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualCollection{T}"/> class.
        /// </summary>
        public VisualCollection()
            : base()
        {
        }

        [JsonInclude, JsonPropertyName("Values")]
        private IEnumerable<T>? Values
        {
            get
            {
                return GetValues();
            }

            set
            {
                SetValues(value);
            }
        }

        /// <summary>
        /// Gets the visual element associated with the specified unique reference.
        /// </summary>
        /// <param name="guidReference">The unique reference of the visual element to retrieve.</param>
        /// <returns>The visual element if found; otherwise, the default value for type <typeparamref name="T"/>.</returns>
        [JsonIgnore]
        public T? this[GuidReference? guidReference]
        {
            get
            {
                if (guidReference is null)
                {
                    return default;
                }

                return dictionary[guidReference];
            }
        }

        /// <summary>
        /// Adds a visual element to the collection.
        /// </summary>
        /// <param name="value">The visual element to add.</param>
        /// <returns><c>true</c> if the element was successfully added; otherwise, <c>false</c>.</returns>
        public bool Add(T? value)
        {
            if (value == null)
            {
                return false;
            }

            dictionary[new GuidReference(value)] = value;
            return true;
        }

        /// <summary>
        /// Removes all visual elements from the collection.
        /// </summary>
        public void Clear()
        {
            dictionary.Clear();
        }

        /// <summary>
        /// Determines whether the collection contains a specific visual element.
        /// </summary>
        /// <param name="value">The visual element to locate in the collection.</param>
        /// <returns><c>true</c> if the element is found; otherwise, <c>false</c>.</returns>
        public bool Contains(T? value)
        {
            if (value == null)
            {
                return false;
            }

            return Contains(new GuidReference(value));
        }

        /// <summary>
        /// Determines whether the collection contains a visual element with the specified unique reference.
        /// </summary>
        /// <param name="guidReference">The unique reference to locate in the collection.</param>
        /// <returns><c>true</c> if the reference is found; otherwise, <c>false</c>.</returns>
        public bool Contains(GuidReference? guidReference)
        {
            if (guidReference is null)
            {
                return false;
            }

            return dictionary.ContainsKey(guidReference);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of visual elements.
        /// </summary>
        /// <remarks>
        /// The enumerator reflects the live contents of the collection; modifying the collection while
        /// enumerating invalidates the enumerator and throws a <see cref="System.InvalidOperationException"/>.
        /// </remarks>
        /// <returns>An enumerator for the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return dictionary.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Retrieves all visual elements currently stored in the collection.
        /// </summary>
        /// <remarks>
        /// Returns a live view over the internal storage rather than a defensive copy; the values are
        /// observed as they are at the moment the returned enumerable is enumerated.
        /// </remarks>
        /// <returns>A live view of the visual elements currently stored in the collection.</returns>
        public IEnumerable<T> GetValues()
        {
            return dictionary.Values;
        }

        /// <summary>
        /// Removes the visual element associated with the specified unique reference from the collection.
        /// </summary>
        /// <param name="guidReference">The unique reference of the element to remove.</param>
        /// <returns><c>true</c> if the element was successfully removed; otherwise, <c>false</c>.</returns>
        public bool Remove(GuidReference? guidReference)
        {
            if (guidReference is null)
            {
                return false;
            }

            return dictionary.Remove(guidReference);
        }

        /// <summary>
        /// Removes the specified visual element from the collection.
        /// </summary>
        /// <param name="value">The visual element to remove.</param>
        /// <returns><c>true</c> if the element was successfully removed; otherwise, <c>false</c>.</returns>
        public bool Remove(T? value)
        {
            if (value == null)
            {
                return false;
            }

            return Remove(new GuidReference(value));
        }

        /// <summary>
        /// Replaces the current contents of the collection with a specified set of visual elements.
        /// </summary>
        /// <param name="values">The new set of visual elements to populate the collection.</param>
        public void SetValues(IEnumerable<T>? values)
        {
            dictionary.Clear();
            if (values == null)
            {
                return;
            }

            foreach (T value in values)
            {
                Add(value);
            }
        }
    }
}