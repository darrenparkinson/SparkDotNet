using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {
        private readonly string peopleBase = "/v1/people";

        /// <summary>
        /// List people in your organization.
        /// </summary>
        /// <param name="email">List people with this email address. For non-admin requests, either this or displayName are required.</param>
        /// <param name="displayName">List people whose name starts with this string. For non-admin requests, either this or email are required.</param>
        /// <param name="ids">List people by ID. Accepts up to 85 person IDs. If this parameter is provided then presence information (such as the lastActivity or status properties) will not be included in the response unless showAllTypes is set to true.</param>
        /// <param name="orgId">List people in this organization. Only admin users of another organization (such as partners) may use this parameter.</param>
        /// <param name="max">Limit the maximum number of people in the response. Default: 100</param>
        /// <param name="callingData">Include BroadCloud user details in the response. Default: false</param>
        /// <param name="locationId">List people present in this location.</param>
        /// <param name="showAllTypes">If the status is removed due to performance issues (ie. when querying via orgId or ids), it can be forced to be returned anyway by setting this to true</param>
        /// <returns>List of People objects.</returns>
        public async Task<List<Person>> GetPeopleAsync(string email = null, string displayName = null, string[] ids = null, string orgId = null, int max = 0, bool? callingData = null, string locationId = null, bool? showAllTypes = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (email != null) queryParams.Add("email",email);
            if (displayName != null) queryParams.Add("displayName",displayName);
            if (ids != null) queryParams.Add("id", string.Join(",", ids));
            if (orgId != null) queryParams.Add("orgId", orgId);
            if (max > 0) queryParams.Add("max",max.ToString());
            if (callingData != null) queryParams.Add("callingData", callingData.ToString());
            if (locationId != null) queryParams.Add("locationId", locationId);
            if (showAllTypes != null) queryParams.Add("showAllTypes", showAllTypes.ToString());
            var path = getURL(peopleBase, queryParams);
            return await GetItemsAsync<Person>(path);
        }

        /// <summary>
        /// Show the profile for the authenticated user.
        /// </summary>
        /// <param name="callingData">Include BroadCloud user details in the response. Default: false</param>
        /// <returns>A person object representing the querying user.</returns>
        public async Task<Person> GetMeAsync(bool? callingData = false) {
            var queryParams = new Dictionary<string, string>();
            if (callingData != null) queryParams.Add("callingData", callingData.ToString());
            var path = getURL($"{peopleBase}/me", queryParams);
            return await GetItemAsync<Person>(path);
        }

        /// <summary>
        /// Shows details for a person, by ID.
        /// Specify the person ID in the personId parameter in the URI.
        /// </summary>
        /// <param name="personId">A unique identifier for the person.</param>
        /// <param name="callingData">Include BroadCloud user details in the response. Default: false</param>
        /// <returns>Person object.</returns>
        public async Task<Person> GetPersonAsync(string personId, bool? callingData = null) {
            var queryParams = new Dictionary<string, string>();
            if (callingData != null) queryParams.Add("callingData", callingData.ToString());
            var path = getURL($"{peopleBase}/{personId}", queryParams);
            return await GetItemAsync<Person>(path);
        }

        /// <summary>
        /// Create a new user account for a given organization. Only an admin can create a new user account.
        /// </summary>
        /// <param name="emails">The email addresses of the person. Only one email address is allowed per person.</param>
        /// <param name="displayName">The full name of the person.</param>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        /// <param name="avatar">The URL to the person's avatar in PNG format.</param>
        /// <param name="orgId">The ID of the organization to which this person belongs.</param>
        /// <param name="roles">An array of role strings representing the roles to which this person belongs.</param>
        /// <param name="licenses">An array of license strings allocated to this person.</param>
        /// <param name="callingData">Include BroadCloud user details in the response. Default: false</param>
        /// <param name="phoneNumbers">Phone numbers for the person.</param>
        /// <param name="extension">The extension of the person retrieved from BroadCloud.</param>
        /// <param name="locationId">The ID of the location for this person retrieved from BroadCloud.</param>
        /// <returns>Person object.</returns>
        public async Task<Person> CreatePersonAsync(string[] emails, string displayName = null, string firstName = null, string lastName = null,
                                                    string avatar = null, string orgId = null, string[] roles = null, string[] licenses = null,
                                                    bool? callingData = null, PhoneNumber[] phoneNumbers = null, string extension = null,
                                                    string locationId = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (callingData != null) queryParams.Add("callingData", callingData.ToString());
            var path = getURL(peopleBase, queryParams);

            var postBody = new Dictionary<string, object>();
            postBody.Add("emails", emails);
            if (displayName != null) postBody.Add("displayName", displayName);
            if (firstName != null) postBody.Add("firstName", firstName);
            if (lastName != null) postBody.Add("lastName", lastName);
            if (avatar != null) postBody.Add("avatar", avatar);
            if (orgId != null) postBody.Add("orgId", orgId);
            if (roles != null) postBody.Add("roles", roles);
            if (licenses != null) postBody.Add("licenses", licenses);
            if (phoneNumbers != null) postBody.Add("phoneNumbers", phoneNumbers);
            if (extension != null) postBody.Add("extension", extension);
            if (locationId != null) postBody.Add("locationId", locationId);


            return await PostItemAsync<Person>(path, postBody);
        }

        /// <summary>
        /// Create a new user account for a given organization. Only an admin can create a new user account.
        /// </summary>
        /// <param name="person">A person object representing the person to be created</param>
        /// <param name="callingData">Include BroadCloud user details in the response. Default: false</param>
        /// <returns>The newly created person</returns>
        public async Task<Person> CreatePersonAsync(Person person, bool? callingData = false)
        {
            return await CreatePersonAsync(person.emails, person.displayName, person.firstName, person.lastName, person.avatar, person.orgId,
                                           person.roles, person.licenses, callingData, person.PhoneNumbers, person.Extension, person.LocationId);
        }

        /// <summary>
        /// Remove a person from the system. Only an admin can remove a person.
        /// Specify the person ID in the personId parameter in the URI.
        /// </summary>
        /// <param name="personId">A unique identifier for the person.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeletePersonAsync(string personId)
        {
            return await DeleteItemAsync($"{peopleBase}/{personId}");
        }

        /// <summary>
        /// Remove a person from the system. Only an admin can remove a person.
        /// Specify the person object in the person parameter in the URI.
        /// </summary>
        /// <param name="person">A person object.</param>
        /// <returns>Boolean indicating success of operation.</returns>
        public async Task<bool> DeletePersonAsync(Person person)
        {
            return await DeletePersonAsync(person.id);
        }

        /// <summary>
        /// Update details for a person, by ID.
        /// Specify the person ID in the personId parameter in the URI. Only an admin can update a person details.
        /// </summary>
        /// <param name="personId">A unique identifier for the person.</param>
        /// <param name="emails">The email addresses of the person. Only one email address is allowed per person.</param>
        /// <param name="orgId">The ID of the organization to which this person belongs.</param>
        /// <param name="roles">An array of role strings representing the roles to which this person belongs.</param>
        /// <param name="displayName">The full name of the person.</param>
        /// <param name="firstName">The first name of the person.</param>
        /// <param name="lastName">The last name of the person.</param>
        /// <param name="avatar">The URL to the person's avatar in PNG format.</param>
        /// <param name="licenses">An array of license strings allocated to this person.</param>
        /// <param name="callingData">Include BroadCloud user details in the response. Default: false</param>
        /// <param name="extension">The extension of the person retrieved from BroadCloud.</param>
        /// <param name="loginEnabled">Whether or not the user is allowed to use Webex. This property is only accessible if the authenticated user is an admin user for the person's organization.</param>
        /// <param name="phoneNumbers">Phone numbers for the person. Can only be set for Webex Calling. Needs a Webex Calling license.</param>
        /// <param name="showAllTypes">Include additional user data like #attendee role</param>
        /// <returns>Person object.</returns>
        public async Task<Person> UpdatePersonAsync(string personId, string displayName, string[] emails = null, string orgId = null, string[] roles = null,
                                                    string firstName = null, string lastName = null, string avatar = null,
                                                    string[] licenses = null, bool? callingData = null, PhoneNumber[] phoneNumbers = null,
                                                    string extension = null, bool? loginEnabled = null, bool? showAllTypes = null)
        {
            var queryParams = new Dictionary<string, string>();
            if (callingData != null) queryParams.Add("callingData", callingData.ToString());
            if (showAllTypes != null) queryParams.Add("showAllTypes", showAllTypes.ToString());
            var path = getURL($"{peopleBase}/{personId}", queryParams);

            var putBody = new Dictionary<string, object>();
            putBody.Add("personId",personId);
            if (emails != null) putBody.Add("emails", emails);
            putBody.Add("displayName", displayName);
            if (firstName != null) putBody.Add("firstName", firstName);
            if (lastName != null) putBody.Add("lastName", lastName);
            if (avatar != null) putBody.Add("avatar", avatar);
            if (orgId != null) putBody.Add("orgId", orgId);
            if (roles != null) putBody.Add("roles", roles);
            if (licenses != null) putBody.Add("licenses", licenses);
            if (phoneNumbers != null) putBody.Add("phoneNumbers", phoneNumbers);
            if (extension != null) putBody.Add("extension", extension);
            if (loginEnabled != null) putBody.Add("extension", loginEnabled);

            return await UpdateItemAsync<Person>(path, putBody);
        }

        /// <summary>
        /// Update details for a person, by ID.
        /// Specify the person ID in the personId parameter in the URI. Only an admin can update a person details.
        /// </summary>
        /// <param name="person">The person object to update</param>
        /// <param name="callingData">Include BroadCloud user details in the response. Default: false</param>
        /// <param name="showAllTypes">Include additional user data like #attendee role</param>
        /// <returns>Person object.</returns>
        public async Task<Person> UpdatePersonAsync(Person person, bool? callingData = null, bool? showAllTypes = null)
        {
            return await UpdatePersonAsync(person.id, person.displayName, person.emails, person.orgId, person.roles,
                                           person.firstName, person.lastName, person.avatar, person.licenses,
                                           callingData, person.PhoneNumbers, person.Extension,  person.LoginEnabled, showAllTypes
);
        }

    }

}