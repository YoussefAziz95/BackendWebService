namespace Application.Model.Notifications
{
    public class ConnectionMapping
    {
        private Dictionary<string, string> _connections =
            new Dictionary<string, string>();

        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public string? Add(string key, string connectionId)
        {
            lock (_connections)
            {
                string oldConnections;
                if (!_connections.TryGetValue(key, out oldConnections))
                {
                    _connections.Add(key, connectionId);
                    return null;
                }
                _connections[key] = connectionId;
                return oldConnections;

            }
        }

        public string? GetConnection(string key)
        {
            string connections;
            if (_connections.TryGetValue(key, out connections))
            {
                return connections;
            }

            return null;
        }
        public Dictionary<string, string> GetConnection()
        {
            var connections = new Dictionary<string, string>();
            foreach (var key in _connections.Keys)
            {
                if (_connections[key] is null)
                    connections.Add(key, "Offline");
                else connections.Add(key, _connections[key]);
            }
            return connections;
        }
        public string? GetKey(string connection)
        {
            return _connections.AsQueryable().Where(c => c.Value == connection).Select(n => n.Value).FirstOrDefault();
        }
        public void Remove(string key)
        {
            if (key is not null)
                lock (_connections)
                {

                    _connections[key] = null;
                }
        }
    }
}
