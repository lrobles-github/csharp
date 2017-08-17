using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace theWall.Models
{
    public class ViewBundle
    {
        public Message MessageModel { get; set; }
        public List<Comment> CommentModels { get; set; }
    }

}