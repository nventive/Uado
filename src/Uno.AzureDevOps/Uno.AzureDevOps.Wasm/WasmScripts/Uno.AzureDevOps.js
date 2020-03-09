var Uno;
(function (Uno) {
    var AzureDevOps;
    (function (AzureDevOps) {
        class Auth {
            static launch(htmlId, url) {
                const uadoTokenStorageKey = "__UadoToken";
                let isProcessingToken = false;
                const cleanUp = () => {
                    window.removeEventListener("message", eventListener);
                    window.removeEventListener("storage", onStorageEvent);
                    window.localStorage.removeItem(uadoTokenStorageKey);
                };
                const eventListener = (msgEvt) => {
                    if (msgEvt.origin !== window.location.origin) {
                        const error = `Message with origin ${msgEvt.origin}ignored. Only origin ${window.location.origin} is allowed.`;
                        console.error(error);
                        return;
                    }
                    if (processData(msgEvt.data)) {
                        try {
                            // Try to close the other tab
                            msgEvt.source.close();
                        }
                        catch (err) {
                        }
                        cleanUp();
                    }
                };
                const onStorageEvent = (storageEvt) => {
                    if (storageEvt.key !== uadoTokenStorageKey) {
                        return; // not a Uado Token
                    }
                    if (processData(storageEvt.newValue)) {
                        cleanUp();
                    }
                };
                const processData = (data) => {
                    if (typeof data !== "string") {
                        return false;
                    }
                    if (data.indexOf("|") < 0) {
                        return false;
                    }
                    const element = document.getElementById(`${htmlId}`);
                    if (!element) {
                        return false;
                    }
                    if (isProcessingToken) {
                        return false;
                    }
                    isProcessingToken = true;
                    var securityTokensEvent = new CustomEvent("urlwithsecuritytokens", {
                        detail: data
                    });
                    element.dispatchEvent(securityTokensEvent);
                    return true;
                };
                // Listen to inter-tab "postMessage" event
                window.addEventListener("message", eventListener);
                // Listen to local storage
                window.addEventListener("storage", onStorageEvent, true);
                return "ok";
            }
        }
        AzureDevOps.Auth = Auth;
    })(AzureDevOps = Uno.AzureDevOps || (Uno.AzureDevOps = {}));
})(Uno || (Uno = {}));
