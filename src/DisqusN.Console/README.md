# Configuring Disqus clients via config files#

Disqus clients can be configured in the App.config for this project *or* in a file called User.SECRETS.config that should be placed in the same directory as this readme. This file should not be checked in if you want this information to remain secret (it is ignored current by git).

The structure of the file User.SECRETS.config should be:

    <DisqusClients>
        <add Name="Client1"
             PublicKey="YourPublicKey"
             PrivateKey="YourPrivateKey"
             AccessToken="YourAccessToken" />
        <add ... />
    </DisqusClients>
    
More than one client's details can be entered.

Only the "Name" and "PublicKey" are required. The "PrivateKey" and "AccessToken" are only required for certain API endpoints. Of course, the access token may only make sense if you are the owner of the disqus client and you are authenticating as that user (and so use your provided access token by Disqus).