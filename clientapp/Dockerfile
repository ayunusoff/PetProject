FROM node:lts-alpine as build

WORKDIR /app
COPY ./clientapp/package*.json .
RUN npm install

COPY ./clientapp/ .
RUN npm run build

FROM nginx:mainline
COPY --from=build /app/dist /usr/share/nginx/html
RUN rm /etc/nginx/conf.d/default.conf
COPY ./nginx.conf /etc/nginx/
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]