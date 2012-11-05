using ZenDeskApi_v2.Models.Requests;
using ZenDeskApi_v2.Models.Tickets;

namespace ZenDeskApi_v2.Requests
{
    public class Requests : Core
    {
        public Requests(string yourZenDeskUrl, string user, string password)
            : base(yourZenDeskUrl, user, password)
        {
        }

        public GroupRequestResponse GetAllRequests()
        {
            return GenericGet<GroupRequestResponse>("requests.json");
        }

        public GroupRequestResponse GetAllSolvedRequests()
        {
            return GenericGet<GroupRequestResponse>("requests/solved.json");
        }

        public GroupRequestResponse GetAllCcdRequests()
        {
            return GenericGet<GroupRequestResponse>("requests/ccd.json");
        }

        public GroupRequestResponse GetAllRequestsForUser(long id)
        {
            return GenericGet<GroupRequestResponse>(string.Format("users/{0}/requests.json", id));
        }

        public  IndividualRequestResponse GetRequestById(long id)
        {
            return GenericGet<IndividualRequestResponse>(string.Format("requests/{0}.json", id));
        }

        public GroupCommentResponse GetRequestCommentsById(long id)
        {
            return GenericGet<GroupCommentResponse>(string.Format("requests/{0}/comments.json", id));
        }

        public IndividualCommentResponse GetSpecificRequestComment(long requestId, long commentId)
        {
            return GenericGet<IndividualCommentResponse>(string.Format("requests/{0}/comments/{1}.json", requestId, commentId));
        }

        public IndividualRequestResponse CreateRequest(Request request)
        {
            var body = new {request};
            return GenericPost<IndividualRequestResponse, object>("requests.json", body);
        }

        public IndividualRequestResponse UpdateRequest(long id, Comment comment)
        {
            var body = new { request = new { comment} };
            return GenericPut<IndividualRequestResponse, object>(string.Format("requests/{0}.json", id), body);
        }
    }
}