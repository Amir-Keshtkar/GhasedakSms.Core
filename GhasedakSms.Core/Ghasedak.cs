using GhasedakSms.Core.Dto;
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
            _url = "https://gw.ghasedak.me/Rest/api/v1/WebService/";
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            _client.DefaultRequestHeaders.Add("ApiKey", apiKey);
        }

        public async Task<ResponseDto<List<SmsStatusResponseItems>>> CheckSmsStatus(CheckSmsStatusQuery query, CancellationToken cancellationToken = default)
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
                return new ResponseDto<List<SmsStatusResponseItems>>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }

        public async Task<ResponseDto<AccountInformationApiResponseDto>> GetAccountInformation(CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync($"{_url}GetAccountInformation", cancellationToken: cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<AccountInformationApiResponseDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<AccountInformationApiResponseDto>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<AccountInformationApiResponseDto>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch { }
                return new ResponseDto<AccountInformationApiResponseDto>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }

        public async Task<ResponseDto<ReceivedSmsesResponse>> GetReceivedSmses(GetReceivedSmsQuery query, CancellationToken cancellationToken = default)
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
                catch { }

                return new ResponseDto<ReceivedSmsesResponse>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }

        public async Task<ResponseDto<ReceivedSmsesPagingResponse>> GetReceivedSmsesPaging(GetReceivedSmsPagingQuery query, CancellationToken cancellationToken = default)
        {
            var queryString = Helper.BuildQueryString($"{_url}GetReceivedSmsesPaging", new Dictionary<string, string>
            {
                {"LineNumber" , query.LineNumber},
                {"IsRead" , query.IsRead.ToString()},
                {"StartDate" , query.StartDate.ToString()},
                {"EndDate" , query.EndDate.ToString()},
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
                catch { }

                return new ResponseDto<ReceivedSmsesPagingResponse>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }

        public async Task<ResponseDto<CheckOtpTemplateDto>> GetOtpTemplateParameters(GetOtpTemplateParametersQuery query, CancellationToken cancellationToken = default)
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
                return new ResponseDto<CheckOtpTemplateDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<CheckOtpTemplateDto>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<CheckOtpTemplateDto>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch { }
                return new ResponseDto<CheckOtpTemplateDto>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }

        }
        public async Task<ResponseDto<SendSingleResponseDto>> SendSingleSMS(SendSingleSmsWebServiceCommand command, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync($"{_url}SendSingleSMS", command, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<SendSingleResponseDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<SendSingleResponseDto>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<SendSingleResponseDto>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch { }
                return new ResponseDto<SendSingleResponseDto>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }

        public async Task<ResponseDto<SendBulkResponse>> SendBulkSMS(SendBulkSmsWebServiceCommand command, CancellationToken cancellationToken = default)
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
                catch { }
                return new ResponseDto<SendBulkResponse>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }

        public async Task<ResponseDto<SendPairToPairResponse>> SendPairToPairSMS(SendPairToPairSmsWebServiceCommand command, CancellationToken cancellationToken = default)
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
                catch { }
                return new ResponseDto<SendPairToPairResponse>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }

        public async Task<ResponseDto<SendOtpResponseDto>> SendOtpSMSOld(SendOtpSmsCommand command, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync($"{_url}SendOtpSMSOld", command, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<SendOtpResponseDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<SendOtpResponseDto>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<SendOtpResponseDto>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch { }
                return new ResponseDto<SendOtpResponseDto>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }

        public async Task<ResponseDto<SendOtpResponseDto>> SendOtpSMS(SendNewOtpSmsCommand command, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response;
            try
            {
                response = await _client.PostAsJsonAsync($"{_url}SendOtpSMS", command, cancellationToken);
            }
            catch (WebException ex)
            {
                return new ResponseDto<SendOtpResponseDto>()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = (int)(ex.Status == WebExceptionStatus.Timeout ? HttpStatusCode.RequestTimeout : HttpStatusCode.InternalServerError)
                };
            }

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseDto<SendOtpResponseDto>>(cancellationToken: cancellationToken);
                return result;
            }
            else
            {
                try
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseDto>(cancellationToken: cancellationToken);
                    return new ResponseDto<SendOtpResponseDto>()
                    {
                        IsSuccess = result.IsSuccess,
                        Message = result.Message,
                        StatusCode = result.StatusCode
                    };
                }
                catch { }
                return new ResponseDto<SendOtpResponseDto>
                {
                    IsSuccess = false,
                    StatusCode = (int)response.StatusCode,
                    Message = response.ReasonPhrase
                };
            }
        }
    }

}
