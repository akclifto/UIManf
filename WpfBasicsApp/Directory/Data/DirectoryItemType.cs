namespace WpfBasicsApp
{
    /// <summary>
    /// Enumerator for different types of directory items.
    /// </summary>
    public enum DirectoryItemType
    {
        /// <summary>
        /// Logical drive
        /// </summary>
        Drive,

        /// <summary>
        /// Folder within directory.
        /// </summary>
        Folder,

        /// <summary>
        /// A physical file.
        /// </summary>
        File
    };
}