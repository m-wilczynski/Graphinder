$(function() {

    $('form').submit(function() {
        if ($(this).valid()) {
            $.ajax({
                async: true,
                url: this.action,
                type: this.method,
                dataType: "json",
                data: $(this).serialize(),
                success: function(result) {
                    renderGraph(result.graph);
                    joinHub(result.hubId)
                }
            });
        }
        return false;
    });

    function renderGraph(graphJson) {

        (function () {

            $("svg").empty();

            var svg = d3.select("svg"),
                width = +svg.attr("width"),
                height = +svg.attr("height");

            var color = d3.scaleOrdinal(d3.schemeCategory20);

            var simulation = d3.forceSimulation()
                .force("link", d3.forceLink().distance(10).strength(0.5))
                .force("charge", d3.forceManyBody())
                .force("center", d3.forceCenter(width / 2, height / 2));

            var nodes = graphJson.Nodes,
                nodeById = d3.map(nodes, function(d) { return d.Key; }),
                links = graphJson.Edges,
                bilinks = [];

            links.forEach(function(link) {
                var s = link.source = nodeById.get(link.Source),
                    t = link.target = nodeById.get(link.Target),
                    i = {};
                nodes.push(i);
                links.push({ source: s, target: i }, { source: i, target: t });
                bilinks.push([s, i, t]);
            });

            var link = svg.selectAll(".link")
                .data(bilinks)
                .enter().append("path")
                .attr("class", "link");

            var node = svg.selectAll(".node")
                .data(nodes.filter(function(d) { return d.Key; }))
                .enter().append("circle")
                .attr("class", "node")
                .attr("r", 5)
                .attr("fill", function(d) { return color(1); })
                .call(d3.drag()
                    .on("start", dragstarted)
                    .on("drag", dragged)
                    .on("end", dragended));

            node.append("title")
                .text(function(d) { return d.Key; });

            simulation
                .nodes(nodes)
                .on("tick", ticked);

            simulation.force("link")
                .links(links);

            function ticked() {
                link.attr("d", positionLink);
                node.attr("transform", positionNode);
            }

            function positionLink(d) {
                return "M" + d[0].x + "," + d[0].y + "S" + d[1].x + "," + d[1].y + " " + d[2].x + "," + d[2].y;
            }

            function positionNode(d) {
                return "translate(" + d.x + "," + d.y + ")";
            }

            function dragstarted(d) {
                if (!d3.event.active) simulation.alphaTarget(0.3).restart();
                d.fx = d.x, d.fy = d.y;
            }

            function dragged(d) {
                d.fx = d3.event.x, d.fy = d3.event.y;
            }

            function dragended(d) {
                if (!d3.event.active) simulation.alphaTarget(0);
                d.fx = null, d.fy = null;
            }
        })();
    }

    function joinHub(hubId) {
        (function () {
            var hub = $.connection.SimulatedAnnealingHub;

            $("#feed").empty();

            hub.client.send = function (report) {

                var msg = '<div class="entry ';
                msg += report.Accepted ? 'bg-success' : 'bg-danger';
                msg += '">';
                msg += '<span class="glyphicon ';
                msg += report.Accepted ? 'glyphicon-ok' : 'glyphicon-remove';
                msg += '" aria-hidden="true"></span>';
                msg += '<strong>Current solution: </strong>' + report.CurrentSolution.length;
                msg += '</div>';

                setTimeout(function() {
                        var feed = document.getElementById("feed");
                        feed.innerHTML += (msg);
                        feed.scrollTop = feed.scrollHeight;
                    },
                    500);
            };

            $.connection.hub.start().done(function() {
                hub.server.joinFeed(hubId);
            });
        })();
    }
});