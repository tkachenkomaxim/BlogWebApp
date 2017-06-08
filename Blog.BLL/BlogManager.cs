using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.ViewModels;
using Blog.DAL;

namespace Blog.BLL
{
    public class BlogSerrvice
    {
        private BlogDataContext _blogContext;

        public BlogSerrvice()
        {
            BlogDataContext _blogContext = new BlogDataContext();
        }

        public List<PostViewModel> GetAllPosts()
        {
            List<PostViewModel> postViewCollection = new List<PostViewModel>();
            List<Post> postsCollection = _blogContext.Posts.ToList();
            foreach (Post post in postsCollection)
            {
                postViewCollection.Add(ConvertPostToPostView(post));
            }
            return postViewCollection;
        }
           
        public PostViewModel GetPost(int Id)
        {
            Post post = _blogContext.Posts.SingleOrDefault(x => x.Id == Id);
            return ConvertPostToPostView(post);
        }

        public void DeletePost(int Id)
        {
            Post post = _blogContext.Posts.SingleOrDefault(x => x.Id == Id);
            _blogContext.Posts.Remove(post);
            _blogContext.SaveChanges();
        }

        public void NewPost(PostViewModel postView)
        {
            postView.Created = DateTime.Now;
            postView.Updated = DateTime.Now;
            Post post = ConvertPostViewToPost(postView);
            _blogContext.Posts.Add(post);
            _blogContext.SaveChanges();
        }

        public void EditPost(PostViewModel postView)
        {
            Post newPost = ConvertPostViewToPost(postView);
            Post oldPost = _blogContext.Posts.Where(x => x.Id == newPost.Id).FirstOrDefault();
            oldPost.Title = newPost.Title;
            oldPost.Content = newPost.Content;
            oldPost.Updated = DateTime.Now;
            _blogContext.SaveChanges();
        }

        private PostViewModel ConvertPostToPostView(Post post)
        {
            PostViewModel postView = new PostViewModel();
            postView.Id = post.Id;
            postView.Title = post.Title;
            postView.Created = post.Created;
            postView.Updated = post.Updated;
            postView.Content = post.Content;
            return postView;
        }

        private Post ConvertPostViewToPost(PostViewModel postView)
        {
            Post post = new Post();
            post.Id = postView.Id;
            post.Title = postView.Title;
            post.Created = postView.Created;
            post.Updated = postView.Updated;
            post.Content = postView.Content;
            return post;
        }
    }
}
