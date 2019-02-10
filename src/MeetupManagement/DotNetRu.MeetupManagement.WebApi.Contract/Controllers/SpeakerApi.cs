#pragma warning disable SA1028 // Code must not contain trailing whitespace
/*
 * Meetup Management Service API
 *
 * Meetup Management Service API
 *
 * OpenAPI spec version: 0.1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
#pragma warning restore SA1028 // Code must not contain trailing whitespace

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DotNetRu.MeetupManagement.WebApi.Contract.Attributes;
using DotNetRu.MeetupManagement.WebApi.Contract.Models;

namespace DotNetRu.MeetupManagement.WebApi.Contract.Controllers
#pragma warning disable SA1028 // Code must not contain trailing whitespace
{ 
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
#pragma warning restore SA1028 // Code must not contain trailing whitespace
#pragma warning disable SA1649
    public abstract class SpeakerApiController : ControllerBase
#pragma warning restore SA1649
#pragma warning disable SA1028 // Code must not contain trailing whitespace
    { 
        /// <summary>
        /// Create speaker draft
        /// </summary>
        
        /// <param name="speakerDraft"></param>
        /// <response code="201">Draft was successfully created</response>
        /// <response code="400">Invalid request parameters</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Draft is already exists</response>
        [HttpPost]
        [Route("/speakers/draft")]
        [ValidateModelState]
        [SwaggerOperation("CreateSpeakerDraft")]
        [SwaggerResponse(statusCode: 201, type: typeof(SpeakerDraft), description: "Draft was successfully created")]
        public abstract ActionResult<SpeakerDraft> CreateSpeakerDraft([FromBody]CreateSpeakerDraftParameters speakerDraft);
        
        /// <summary>
        /// Delete speaker draft
        /// </summary>
        
        /// <param name="speakerId"></param>
        /// <response code="204">Draft was successfuly deleted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Speaker not found</response>
        [HttpDelete]
        [Route("/speakers/{speakerId}/draft")]
        [ValidateModelState]
        [SwaggerOperation("DeleteSpeakerDraft")]
        public abstract EmptyResult DeleteSpeakerDraft([FromRoute][Required]string speakerId);
        
        /// <summary>
        /// Get speaker draft
        /// </summary>
        
        /// <param name="speakerId"></param>
        /// <response code="200">OK</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Speaker not found</response>
        [HttpGet]
        [Route("/speakers/{speakerId}/draft")]
        [ValidateModelState]
        [SwaggerOperation("GetSpeakerDrafts")]
        [SwaggerResponse(statusCode: 200, type: typeof(SpeakerDraft), description: "OK")]
        public abstract ActionResult<SpeakerDraft> GetSpeakerDrafts([FromRoute][Required]string speakerId);
        
        /// <summary>
        /// Update speaker draft
        /// </summary>
        
        /// <param name="speakerId"></param>
        /// <param name="body"></param>
        /// <response code="204">Draft was successfuly updated</response>
        /// <response code="400">Invalid request parameters</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Speaker not found</response>
        [HttpPut]
        [Route("/speakers/{speakerId}/draft")]
        [ValidateModelState]
        [SwaggerOperation("UpdateSpeakerDraft")]
        public abstract EmptyResult UpdateSpeakerDraft([FromRoute][Required]string speakerId, [FromBody]UpdateSpeakerDraftParameters body);
        
        /// <summary>
        /// Get route values for CreateSpeakerDraft action
        /// </summary>
        protected static object GetCreateSpeakerDraftRouteValues()
        {
            return new { };
        }

        /// <summary>
        /// Get route values for DeleteSpeakerDraft action
        /// </summary>
        protected static object GetDeleteSpeakerDraftRouteValues([FromRoute][Required]string speakerId)
        {
            return new { speakerId };
        }

        /// <summary>
        /// Get route values for GetSpeakerDrafts action
        /// </summary>
        protected static object GetGetSpeakerDraftsRouteValues([FromRoute][Required]string speakerId)
        {
            return new { speakerId };
        }

        /// <summary>
        /// Get route values for UpdateSpeakerDraft action
        /// </summary>
        protected static object GetUpdateSpeakerDraftRouteValues([FromRoute][Required]string speakerId)
        {
            return new { speakerId };
        }
    }
#pragma warning restore SA1028 // Code must not contain trailing whitespace
}
