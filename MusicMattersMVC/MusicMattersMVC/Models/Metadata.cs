using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersMVC.Models
{
    public class AlbumMetadata
    {
        public int Id;
        public int ArtistId;
        public string Name;
        public Nullable<System.DateTime> ReleaseDate;
        public string Image;
        public byte IsAdminApproved;
    }

    public class ArtistMetadata
    {
        public int Id;
        public string Name;
        public string Image;
        public string Description;
        public Nullable<System.DateTime> ActiveFrom;
        public Nullable<System.DateTime> ActiveUntil;
        public byte IsAdminApproved;
    }

    public class CommentMetadata
    {
        public int Id;
        public int UserId;
        public string Content;
        public Nullable<int> ReplyId;
        public System.DateTime TimeCreated;
        public Nullable<System.DateTime> TimeEdited;
    }

    public class SongMetadata
    {
        public int Id;
        public Nullable<int> AlbumId;
        public string Name;
        public Nullable<System.TimeSpan> Length;
        public Nullable<byte> IsSingle;
        public byte IsAdminApproved;
    }

    public class UserMetadata
    {
        [StringLength(50, MinimumLength = 5)]
        public string Username;

        [StringLength(64)]
        public string Pass;                         //Used for hash stored in DB.

        [StringLength(64)]
        public string Salt;

        [Display(Name = "Email address")]
        [StringLength(100, MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-]+$")]
        public string Email;

        [StringLength(100, MinimumLength = 5)]
        [Display(Name = "Profile picture")]
        public string Avatar;
    }
}