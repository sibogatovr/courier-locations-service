import http from 'k6/http';
import { check } from 'k6';

export const options = {
    vus: 1,           
    iterations: 10000, 
};

function rand(min, max) {
    return Math.round(Math.random() * (max - min) + min);
}

const courierIds = Array.from({ length: 50 }, () => crypto.randomUUID());

export default function () {
    const baseUrl = 'http://localhost:5074/api/couriers';
    const courierId = courierIds[Math.floor(Math.random() * courierIds.length)];
    const url = `${baseUrl}/${courierId}/locations`;

    const params = {
        headers: { 'Content-Type': 'application/json' },
    };

    const count = rand(1, 1);
    let locations = [];

    for (let i = 0; i < count; i++) {
        locations.push({
            latitude: 55.75 + Math.random() / 100,
            longitude: 37.61 + Math.random() / 100,
            accuracy: rand(1, 10),
            locateDateTime: new Date().toISOString()
        });
    }

    const payload = JSON.stringify(locations);

    const res = http.post(url, payload, params);

    check(res, {
        'status is 200': (r) => r.status === 200
    });
}
