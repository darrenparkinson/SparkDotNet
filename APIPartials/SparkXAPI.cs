
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkDotNet
{

    public partial class Spark
    {

        private readonly string xAPIBase = "/v1/xapi";

        /// <summary>
        /// Query the current status of the Webex RoomOS Device.
        /// Specify the target device in the deviceId parameter in the URI.
        /// The target device is queried for statuses according to the expression in the name parameter.
        /// See the xAPI Guide for a description of status expressions.
        /// </summary>
        /// <param name="deviceId">The unique identifier for the Webex RoomOS Device.</param>
        /// <param name="name">Status expression used to query the Webex RoomOS Device.</param>
        /// <returns>The xAPI status of the device</returns>
        public async Task<XAPIStatus> QueryStatusAsync(string deviceId, string name)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("deviceId", deviceId);
            queryParams.Add("name", name);
            var path = getURL($"{xAPIBase}/status", queryParams);
            return await GetItemAsync<XAPIStatus>(path);
        }

        /// <summary>
        /// Query the current status of the Webex RoomOS Device.
        /// Specify the target device in the deviceId parameter in the URI.
        /// The target device is queried for statuses according to the expression in the name parameter.
        /// See the xAPI Guide for a description of status expressions.
        /// </summary>
        /// <param name="device">The device object to query.</param>
        /// <param name="name">Status expression used to query the Webex RoomOS Device.</param>
        /// <returns>The xAPI status of the device</returns>
        public async Task<XAPIStatus> QueryStatusAsync(Device device, string name)
        {
            return await QueryStatusAsync(device.Id, name);
        }

        /// <summary>
        /// Execute a command on the Webex RoomOS Device.
        /// Specify the command to execute in the commandName parameter in the URI.
        /// See the xAPI Guide for a description of command expressions.
        /// </summary>
        /// <param name="commandName">Command to execute on the Webex RoomOS Device.</param>
        /// <param name="deviceId">The unique identifier for the Webex RoomOS Device.</param>
        /// <param name="arguments">xAPI command arguments</param>
        /// <returns></returns>
        public async Task<XAPIStatus> ExecuteCommandAsync(string commandName, string deviceId, object arguments = null)
        {
            var postBody = new Dictionary<string, object>();
            postBody.Add("commandName", commandName);
            postBody.Add("deviceId", deviceId);
            postBody.Add("arguments", arguments);
            return await PostItemAsync<XAPIStatus>($"{xAPIBase}/{commandName}", postBody);
        }

        /// <summary>
        /// Execute a command on the Webex RoomOS Device.
        /// Specify the command to execute in the commandName parameter in the URI.
        /// See the xAPI Guide for a description of command expressions.
        /// </summary>
        /// <param name="commandName">Command to execute on the Webex RoomOS Device.</param>
        /// <param name="device">The Webex RoomOS Device object.</param>
        /// <param name="arguments">xAPI command arguments</param>
        /// <returns></returns>
        public async Task<XAPIStatus> ExecuteCommandAsync(string commandName, Device device, object arguments = null)
        {
            return await ExecuteCommandAsync(commandName, device.Id, arguments);
        }
    }

}