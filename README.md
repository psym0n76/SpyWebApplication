This ASP.Core Web Application will take a Message and SpyName name as input parameters and return true
if the SpyName is hidden within the message.

Set up a GET request (Postman) to the following URL
    https://localhost:44341/api/cipher/decode
    
 Add two Query Parameters:
    message = [0,2,4,0,0,7,5]
    spyname = James Bond

 Successful reponse should be: 
    1. James Bond is hiding in the message.
    2. James Bond is not hiding in the message.
 
 Unsuccessful response should be:
    1. Bad Data: Simon Burton is not found in the Spy Database.
    2. Bad Data: message and spyname must be populated.

  
  
