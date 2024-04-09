/*
import http from 'k6/http';
import { check, sleep } from 'k6';

export let options = {
    vus: 10,
    duration: '30s',
};

export default function () {
    let response = http.get('http://localhost:5000/conversion/history');

    check(response, {
        'status is 200': (r) => r.status === 200,
        'response body is not empty': (r) => r.body.length > 0,
        'response contains success message': (r) => r.body.includes('Conversion history fetched successfully'),
    });

    sleep(1);
}
*/
