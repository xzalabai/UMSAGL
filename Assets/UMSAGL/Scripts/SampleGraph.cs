using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleGraph : MonoBehaviour {

	public GameObject graphPrefab;
    public GameObject nodePrefab;
    public GameObject edgePrefab;
	private Graph graph;

	private IEnumerator LayoutTest()
	{
		//relayout test after 10s
		yield return new WaitForSecondsRealtime(10);
		graph.Layout();
	}

	void Start () {
		//Instantiate graph
		var go = GameObject.Instantiate(graphPrefab);
		graph = go.GetComponent<Graph>();

		//Generate
		Generate();

		//Relayout after 10s, for testing purposes only
		StartCoroutine(LayoutTest());
	}

	void Generate()
	{
		//Demonstration how to create graph using provided API
		var a = graph.AddNode();
		var b = graph.AddNode();

		int count = 5;

		for (int i = 0; i < count; i++)
		{
			var n = graph.AddNode();
			graph.AddEdge(a, n);
			n = graph.AddNode();
			graph.AddEdge(b, n);
		}

        //same with custom GO
        for (int i = 0; i < count; i++)
        {
            var node = GameObject.Instantiate(nodePrefab, graph.Units);
            graph.AddNode(node);
            var edge = GameObject.Instantiate(edgePrefab, graph.Units);
            graph.AddEdge(edge, a, node);
            node = GameObject.Instantiate(nodePrefab, graph.Units);
            graph.AddNode(node);
            edge = GameObject.Instantiate(edgePrefab, graph.Units);
            graph.AddEdge(edge, b, node);
        }

        graph.AddEdge(a, b);

		graph.Layout();
	}
}
