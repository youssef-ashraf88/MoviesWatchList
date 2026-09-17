import http from 'k6/http';

export const options = {
    stages: [
        { duration: '10s', target: 100 },
        { duration: '10s', target: 250 },
        { duration: '10s', target: 500 },
        { duration: '10s', target: 750 },
        { duration: '10s', target: 1000 },
    ],
};

export default function () {
    http.get('https://localhost:7182/api/Movies');
}