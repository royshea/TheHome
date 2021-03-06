﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using SmartSharp;
using SmartSharp.RequestModels;

namespace TheHome.Controllers
{
    [Produces("application/json")]
    [Route("api/Lifecycle")]
    public class LifecycleController : Controller
    {
        // POST: api/Lifecycle
        [HttpPost]
        public ActionResult Post([FromBody]ExecutionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            switch (request.LifeCycle)
            {
                case Enums.LifeCycleEnum.INSTALL:
                    return HandleInstall((InstallRequest) request);
                case Enums.LifeCycleEnum.UPDATE:
                    return HandleUpdate((UpdateRequest) request);
                case Enums.LifeCycleEnum.UNINSTALL:
                    return HandleUninstall((UninstallRequest) request);
                case Enums.LifeCycleEnum.EVENT:
                    return HandleEvent((EventRequest) request);
                case Enums.LifeCycleEnum.PING:
                    return HandlePing((PingRequest) request);
                case Enums.LifeCycleEnum.CONFIGURATION:
                    return HandleConfig((ConfigurationRequest) request);
                case Enums.LifeCycleEnum.OAUTH_CALLBACK:
                    return HandleOAuthCallback((OAuthCallbackRequest) request);
                default:
                    throw new NotImplementedException("Unknown lifecycle");
            }
        }

        private ActionResult HandlePing(PingRequest request)
        {
            var response = new PingResponse() { PingData = request.PingData };
            return Ok(response);
        }

        private ActionResult HandleConfig(ConfigurationRequest request)
        {
            switch (request.ConfigurationData.Phase)
            {
                case Enums.PhaseEnum.INITIALIZE:
                    return SendInitializeResponse(request);
                case Enums.PhaseEnum.PAGE:
                    return SendPageResponse(request);
                default:
                    throw new NotImplementedException("Unknown phase");
            }
        }

        private ActionResult SendInitializeResponse(ConfigurationRequest request)
        {
            var responseString = @"
            {
              ""configurationData"": {
                ""initialize"": {
                            ""name"": ""On When Open\/Off When Shut WebHook App"",
                  ""description"": ""On When Open\/Off When Shut WebHook App"",
                  ""id"": ""app"",
                  ""permissions"": [
                    ""l:devices""
                  ],
                  ""firstPageId"": ""1""
                }
            }
            }
            ";

            var response = JsonConvert.DeserializeObject<ConfigurationInitResponse>(responseString);
            return Ok(response);
        }

        private ActionResult SendPageResponse(ConfigurationRequest request)
        {
            string responseString = @"{
                ""configurationData"": {
                ""page"": {
                    ""pageId"": ""1"",
                    ""name"": ""On When Open\/Off When Shut WebHook App"",
                    ""nextPageId"": null,
                    ""previousPageId"": null,
                    ""complete"": true,
                    ""sections"": [
                    {
                        ""name"": ""When this opens\/closes..."",
                        ""settings"": [
                        {
                            ""id"": ""contactSensor"",
                            ""name"": ""Which contact sensor?"",
                            ""description"": ""Tap to set"",
                            ""type"": ""DEVICE"",
                            ""required"": true,
                            ""multiple"": false,
                            ""capabilities"": [
                            ""contactSensor""
                            ],
                            ""permissions"": [
                            ""r""
                            ]
                        }
                        ]
                    },
                    {
                        ""name"": ""Turn on\/off this light..."",
                        ""settings"": [
                        {
                            ""id"": ""lightSwitch"",
                            ""name"": ""Which switch?"",
                            ""description"": ""Tap to set"",
                            ""type"": ""DEVICE"",
                            ""required"": true,
                            ""multiple"": false,
                            ""capabilities"": [
                            ""switch""
                            ],
                            ""permissions"": [
                            ""r"",
                            ""x""
                            ]
                        }
                        ]
                    }
                    ]
                }
                }
                }";
            ConfigurationPageResponse response;
            response = JsonConvert.DeserializeObject<ConfigurationPageResponse>(responseString);
            return Ok(response);
        }

        private ActionResult HandleInstall(InstallRequest request)
        {
            var responseString = @"
            {
                ""installData"": {}
            }
            ";
            var response = JsonConvert.DeserializeObject<ConfigurationInitResponse>(responseString);
            return Ok(response);
        }

        private ActionResult HandleUpdate(UpdateRequest request)
        {
            var responseString = @"
            {
                ""updateData"": {}
            }
            ";
            var response = JsonConvert.DeserializeObject<UpdateResponse>(responseString);
            return Ok(response);
        }

        private ActionResult HandleEvent(EventRequest request)
        {
            var responseString = @"
            {
                ""eventData"": {}
            }
            ";
            var response = JsonConvert.DeserializeObject<EventResponse>(responseString);
            return Ok(response);
        }

        private ActionResult HandleOAuthCallback(OAuthCallbackRequest request)
        {
            var responseString = @"
            {
                ""oAuthCallbackData"": {}
            }
            ";
            var response = JsonConvert.DeserializeObject<OauthCallbackResponse>(responseString);
            return Ok(response);
        }

        private ActionResult HandleUninstall(UninstallRequest request)
        {
            var responseString = @"
            {
                ""uninstallData"": {}
            }
            ";
            var response = JsonConvert.DeserializeObject<UninstallResponse>(responseString);
            return Ok(response);
        }
    }
}
