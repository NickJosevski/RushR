### SignalR app demo steps

 1. File New Project
 2. Add SignalR
 3. Add hubs folder
 4. Create NotifyHub
   - Broadcast method  
 5. Configure JS
    - RegisterBundles
    - src="/signalr/hubs"
 6. Add signalR to the bundles:  
<span>  
	    - bundles.Add(new ScriptBundle("~/bundles/jquery").Include(  
		"~/Scripts/jquery-1.*",  
		"~/Scripts/jquery.signalR-*",  
		"~/signalr/hubs"));  
</span>
 7. 