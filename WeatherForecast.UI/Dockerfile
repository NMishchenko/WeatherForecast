# Stage 1
FROM node:latest as node
WORKDIR /app
COPY . .
RUN npm install --force
RUN npm run build --prod

# Stage 2
FROM nginx:alpine
COPY --from=node /app/dist/weather-forecast.ui /usr/share/nginx/html

# Expose port 80
EXPOSE 80
