using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Repositories
{
    public interface ICommentRepository
    {
        IList<CommentEntity> findAll();
    }
}