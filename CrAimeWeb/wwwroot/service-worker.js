self.addEventListener("install", event => {
    event.waitUntil(
        caches.open("craime-cache").then(cache => {
            return cache.addAll([
                "/",
                "/css/site.css",
                "/img/craime-logo.svg",
                "/js/Modal.js",
                "/js/dataEvent.js",
                "/js/dataPartenaire.js",
                "/js/dataStock.js",
                "/js/dataUser.js",
                "/js/site.js",
                "/Home/User",
                "/Home/Partenaire",
                "/Home/Stock",
                "/Home/Evenement",
            ]);
        })
    );
});

self.addEventListener("fetch", event => {
    event.respondWith(
        caches.match(event.request).then(response => {
            return response || fetch(event.request);
        })
    );
});

self.addEventListener("activate", event => {
    event.waitUntil(
        caches.keys().then(cacheNames => {
            return Promise.all(
                cacheNames.filter(cacheName => {
                    return cacheName.startsWith("craime-cache-") && cacheName !== "craime-cache";
                }).map(cacheName => {
                    return caches.delete(cacheName);
                })
            );
        })
    );
});