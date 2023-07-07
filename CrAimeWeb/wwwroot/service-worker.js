self.addEventListener("install", event => {
    event.waitUntil(
        caches.open("craime-cache").then(cache => {
            return cache.addAll([
                "/",
                "/css/site.css",
                "/img/craime-logo.svg"
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