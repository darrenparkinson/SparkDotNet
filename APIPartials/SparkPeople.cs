using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {
        private string peopleBase = "/v1/people";

        /// <summary>
        /// List people in your organization.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="displayName"></param>
        /// <param name="max"></param>
        /// <returns>List of People objects.</returns>
        public async Task<List<Person>> GetPeopleAsync(string email = null, string displayName = null, int max = 0)
        {
            var queryParams = new Dictionary<string, string>();
            if (email != null) queryParams.Add("email",email);
            if (displayName != null) queryParams.Add("displayName",displayName);
            if (max > 0) queryParams.Add("max",max.ToString());
            var path = getURL(peopleBase, queryParams);
            return await GetItemsAsync<Person>(path);
        }

        /// <summary>
        /// Show the profile for the authenticated user.
        /// </summary>
        /// <returns></returns>
        public async Task<Person> GetMeAsync() {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{peopleBase}/me", queryParams);
            return await GetItemAsync<Person>(path);
        }

        /// <summary>
        /// Shows details for a person, by ID.
        /// Specify the person ID in the personId parameter in the URI.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>Person object.</returns>
        public async Task<Person> GetPersonAsync(string personId) {
            var queryParams = new Dictionary<string, string>();
            var path = getURL($"{peopleBase}/{personId}", queryParams);
            return await GetItemAsync<Person>(path);
        }

        /// <summary>
        /// Create a new user account for a given organization. Only an admin can create a new user account.
        /// </summary>
        /// <param name="emails"></param>
        /// <param name="displayName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="avatar"></param>
        /// <param name="orgId"></param>
        /// <param name="roles"></param>
        /// <param name="licenses"></param>
        /// <returns>Person object.</returns>
        public async Task<Person> CreatePersonAsync(string[] emails, string displayName = null, string firstName = null, string lastName = null, string avatar = null, string orgId = null, string[] roles = null, string[] licenses = null )
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("emails", emails);
            if (displayName != null) { postBody.Add("displayName", displayName); }
            if (firstName != null) { postBody.Add("firstName", firstName); }
            if (lastName != null) { postBody.Add("lastName", lastName); }
            if (avatar != null) { postBody.Add("avatar", avatar); }
            if (orgId != null) { postBody.Add("orgId", orgId); }
            if (roles != null) { postBody.Add("roles", roles); }
            if (licenses != null) { postBody.Add("licenses", licenses); }

            return await PostItemAsync<Person>(peopleBase, postBody);
        }

        /// <summary>
        /// Remove a person from the system. Only an admin can remove a person.
        /// Specify the person ID in the personId parameter in the URI.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeletePersonAsync(string personId)
        {
            return await DeleteItemAsync($"{peopleBase}/{personId}");            
        }

        /// <summary>
        /// Update details for a person, by ID.
        /// Specify the person ID in the personId parameter in the URI. Only an admin can update a person details.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="emails"></param>
        /// <param name="orgId"></param>
        /// <param name="roles"></param>
        /// <param name="displayName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="avatar"></param>
        /// <param name="licenses"></param>
        /// <returns>Person object.</returns>
        public async Task<Person> UpdatePersonAsync(string personId, string[] emails, string orgId, string[] roles, string displayName = null, string firstName = null, string lastName = null, string avatar = null, string[] licenses = null )
        {
            var putBody = new Dictionary<string, object>();
            putBody.Add("personId",personId);
            putBody.Add("emails", emails);
            if (displayName != null) { putBody.Add("displayName", displayName); }
            if (firstName != null) { putBody.Add("firstName", firstName); }
            if (lastName != null) { putBody.Add("lastName", lastName); }
            if (avatar != null) { putBody.Add("avatar", avatar); }
            if (orgId != null) { putBody.Add("orgId", orgId); }
            if (roles != null) { putBody.Add("roles", roles); }
            if (licenses != null) { putBody.Add("licenses", licenses); }
            var path = $"{peopleBase}/{personId}";
            return await UpdateItemAsync<Person>(path, putBody);
        }

    }

}