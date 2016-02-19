// https://disqus.com/api/docs/errors/

//Error Codes
//
//Every error is represented with an HTTP status code, as well as a code and response message within the actual response body.
//
//There are two exceptions to these rules:
//
//Invalid formats will return an HTTP 415 with an error message as the response body.
//JSONP without a callback will return a javascript commented response.
//HTTP Code    Meaning
//200	0	Success
//400	1	Endpoint not valid
//400	2	Missing or invalid argument
//400	3	Endpoint resource not valid
//401	4	You must be authenticated to perform this action
//403	5	Invalid API key
//400	6	Invalid API version
//400	7	You cannot access this resource using %(request_method)s
//404	8	A requested object was not found
//400	9	You cannot access this resource using your %(access_type)s API key
//400	10	This operation is not supported
//400	11	Your API key is not valid on this domain
//400	12	This application does not have enough privileges to access this resource
//400	13	You have exceeded the rate limit for this resource
//400	14	You have exceeded the rate limit for your account
//500	15	There was internal server error while processing your request
//408	16	Your request timed out
//400	17	The authenticated user does not have access to this feature
//400	18	The authorization signature you passed was not valid
//400	19	You must re-submit this request with a response to the captcha challenge
//503	20	The API is currently undergoing maintenance, and your changes were saved, but will not be visible yet.
//503	21	The API is currently undergoing maintenance, and your changes could not be saved.
//400	22	You do not have the appropriate permissions to access this resource
//400	23	You must be authenticated and verified by the forum owner to perform this action
//400	24	You have exceeded the maximum number of creations for this resource
