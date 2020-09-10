#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM nginx
COPY nginx.conf /etc/nginx/nginx.conf