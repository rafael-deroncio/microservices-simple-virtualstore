DROP TRIGGER IF EXISTS update_service_trigger ON Logs;
DROP FUNCTION IF EXISTS update_service_column();
DROP TABLE IF EXISTS Logs;

CREATE TABLE IF NOT EXISTS Logs (
    log_id SERIAL PRIMARY KEY,
    service TEXT,
    envioroment TEXT,
    message TEXT,
    message_template TEXT,
    level INT,
    timestamp TIMESTAMP,
    exception TEXT,
    log_event JSONB
);

CREATE OR REPLACE FUNCTION update_service_column()
RETURNS TRIGGER AS $$
BEGIN
    NEW.service := (regexp_matches(NEW.log_event::text, '"ServiceName": "([^"]+)"'))[1];
	NEW.envioroment := (regexp_matches(NEW.log_event::text, '"Envioroment": "([^"]+)"'))[1];
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER update_service_trigger
BEFORE INSERT ON "logs"
FOR EACH ROW
EXECUTE FUNCTION update_service_column();
