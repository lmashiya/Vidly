namespace Vidly.DTOs
{
    public class MembershipTypeDto
    {
        /// <summary>
        ///     Gets or sets a <see cref="byte"/> representing membership id.
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref="string"/> representing membership type name.
        /// </summary>
        public string Name { get; set; }
    }
}