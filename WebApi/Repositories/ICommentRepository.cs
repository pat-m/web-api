using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ICommentRepository
    {
        IList<CommentEntity> findAll();
    }
}