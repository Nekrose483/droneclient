# Introduction #

The client and server communicate via XML. This page describes the protocol.

**Note**: Currently, our XML parser cannot parse the name or value of the root node, so we're just naming the root node <.> for now.  If we improve the parser, then we can use the root node more effectively.

# Chat #

Example chat xml (server to client):
```
<x>
	<type>chat</type>
	<admin>1</admin>   				(if applicable)
	<from>sender_name</from>
	<to>recipient_name</to>
	<channel>channel_name</channel>
	<message>message_text</message>
</x>
```

Example chat xml (client to server):
```
<x>
	<type>chat</type>
	<to>recipient_name</to>             (not needed or 0, if msg is to all)
	<channel>channel_name</channel>     (not needed or 0, if msg is to lobby)
	<message>message_text</message>
</x>
```

Asking the server for tasks:
```
<x>
	<type>gettask</type>
        <username>username</username>       (username of the person whose tasks you're requesting)
</x>
```


Asking the server for online family members:
```
<x>
	<type>requestFamilyMembers</type>
</x>
```


Task\_Attempts
```
<x>
        <rejected>0</rejected>  //if rejected then make the task say rejected 
        <taskid>id of specific task</taskid>
        <attempt_date>DateTime</attempt_date>
        <proof>string</proof>
        <outcome>0=pending;1=approved;2=rejected;</outcome>
        <comments>comments</comments>
        <decision_date>DateTime</decision_date>
</x>
```


when you login, this is what is sent

Outgoing.WriteLine (DCConstants.Username + ":" + DCConstants.Password + ":" + DCConstants.authpattern);

authpattern will be a public key for the server to use to encrypt messages for the client. the client will have a hidden key.. the client will then encrypt stuff to the server by downloading a public key from the website and using that to encrypt to the server. the public server key will be changed once a week and drone client will need to update in order to stay in the encryption loop