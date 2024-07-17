using GhasedakSms.Core.Dto;
using Microsoft.VisualBasic;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Text.Encodings.Web;

namespace GhasedakSms.Core
{
    public class Ghasedak
    {
        private readonly HttpClient _client;
        private readonly string _url;

        public Ghasedak(string apiKey)
        {
            _url = "http://gw.ghasedak.me/rest/api/v1/WebService/";
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            _client.DefaultRequestHeaders.Add("ApiKey", apiKey);
        }

        public async Task<ResponseDto<List<SmsStatusResponseItems>>> CheckSmsStatus(CheckSmsStatusInput query, CancellationToken cancellationToken = default)
        {
            var queryString = Helper.BuildQueryString($"{_url}CheckSmsStatus", new Dictionary<string, string>
            {
                { "Type", query.Type.ToString() }
            }, "Ids", query.Ids);

            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(queryString, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<List<SmsStatusResponseItems>>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<List<SmsStatusResponseItems>>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<List<SmsStatusResponseItems>>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch
                {
                    return new ResponseDto<List<SmsStatusResponseItems>>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<ResponseDto<AccountInformationResponse>> GetAccountInformation(CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync($"{_url}GetAccountInformation", cancellationToken: cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<AccountInformationResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<AccountInformationResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<AccountInformationResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch
                {
                    return new ResponseDto<AccountInformationResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<ResponseDto<ReceivedSmsesResponse>> GetReceivedSmses(GetReceivedSmsInput query, CancellationToken cancellationToken = default)
        {
            var queryString = Helper.BuildQueryString($"{_url}GetReceivedSmses", new Dictionary<string, string>
            {
                { "LineNumber", query.LineNumber },
                { "IsRead", query.IsRead.ToString() }
            });
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(queryString, cancellationToken: cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<ReceivedSmsesResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<ReceivedSmsesResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<ReceivedSmsesResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        StatusCode = (int)result.StatusCode,
                        Message = result.Message
                    };
                }
                catch
                {
                    return new ResponseDto<ReceivedSmsesResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<ResponseDto<ReceivedSmsesPagingResponse>> GetReceivedSmsesPaging(GetReceivedSmsPagingInput query, CancellationToken cancellationToken = default)
        {
            var queryString = Helper.BuildQueryString($"{_url}GetReceivedSmsesPaging", new Dictionary<string, string>
            {
                {"LineNumber" , query.LineNumber},
                {"IsRead" , query.IsRead.ToString()},
                {"StartDate" , query.StartDate.ToString("yyyy-MM-ddTHH:mm:ss")},
                {"EndDate" , query.EndDate.ToString("yyyy-MM-ddTHH:mm:ss")},
                {"PageIndex" , query.PageIndex.ToString()},
                {"PageSize" , query.PageSize.ToString() },
            });

            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(queryString, cancellationToken: cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<ReceivedSmsesPagingResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<ReceivedSmsesPagingResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<ReceivedSmsesPagingResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        StatusCode = result.StatusCode,
                        Message = result.Message
                    };
                }
                catch
                {
                    return new ResponseDto<ReceivedSmsesPagingResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<ResponseDto<CheckOtpTemplateResponse>> GetOtpParameters(GetOtpParametersInput query, CancellationToken cancellationToken = default)
        {
            var queryString = Helper.BuildQueryString($"{_url}GetOtpTemplateParameters", new Dictionary<string, string>
            {
                { "TemplateName", query.TemplateName },
            });
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(queryString, cancellationToken: cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<CheckOtpTemplateResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<CheckOtpTemplateResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<CheckOtpTemplateResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch
                {
                    return new ResponseDto<CheckOtpTemplateResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }

        }

        public async Task<ResponseDto<SendSingleResponse>> SendSingleSMS(SendSingleSmsInput command, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync($"{_url}SendSingleSMS", command, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<SendSingleResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<SendSingleResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<SendSingleResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch
                {
                    return new ResponseDto<SendSingleResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<ResponseDto<SendBulkResponse>> SendBulkSMS(SendBulkInput command, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync($"{_url}SendBulkSMS", command, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<SendBulkResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<SendBulkResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<SendBulkResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch
                {
                    return new ResponseDto<SendBulkResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<ResponseDto<SendPairToPairResponse>> SendPairToPairSMS(SendPairToPairInput command, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync($"{_url}SendPairToPairSMS", command, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<SendPairToPairResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<SendPairToPairResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<SendPairToPairResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch
                {
                    return new ResponseDto<SendPairToPairResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<ResponseDto<SendOtpResponse>> SendOtpWithParams(SendOldOtpInput command, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync($"{_url}SendOtpWithParams", command, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<SendOtpResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<SendOtpResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<SendOtpResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch
                {
                    return new ResponseDto<SendOtpResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }

        public async Task<ResponseDto<SendOtpResponse>> SendOtpSMS(SendOtpInput command, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync($"{_url}SendOtpSMS", command, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<SendOtpResponse>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<SendOtpResponse>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<SendOtpResponse>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch
                {
                    return new ResponseDto<SendOtpResponse>
                    {
                        IsSuccess = false,
                        StatusCode = (int)response.StatusCode,
                        Message = response.ReasonPhrase
                    };
                }
            }
        }
    }
}
