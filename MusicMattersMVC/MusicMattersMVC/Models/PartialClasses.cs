using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersMVC.Models
{
    [MetadataType(typeof(AlbumMetadata))]
    public partial class Album
    {
    }

    [MetadataType(typeof(ArtistMetadata))]
    public partial class Artist
    {
    }

    [MetadataType(typeof(CommentMetadata))]
    public partial class Comment
    {
    }

    [MetadataType(typeof(SongMetadata))]
    public partial class Song
    {
    }

    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }
}