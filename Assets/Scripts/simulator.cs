using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Simulator class manage the components, nodes, current and voltages
    in the circuit.
*/
public class simulator : MonoBehaviour
{
    List<GameObject> components = new List<GameObject>();
    List<node> nodes = new List<node>();
    private int nodes_cnt = 0;
    public float circuit_current = 0.0f;

    // Unique id per node.
    private string nextId(){
        return (nodes_cnt++).ToString();
    }

    // Adds a new component when the OnTargetFound() function is triggered.
    public void addComponent(GameObject component){
        components.Add(component);
    }

    // Remove an existing component and their nodes when the OnTargetFound() function is triggered.
    public void removeComponent(GameObject component){
        removeNodebyComponent(component);
        components.Remove(component);

    }

    public void sortNodes(){
        nodes.Sort((n1, n2) => n2.isSupply.CompareTo(n1.isSupply));
    }

    // Creates a new node when a OnTriggerEnter() function of a Pin class is triggered.
    public void setNode( pin pin1, pin pin2 ){
        bool node_exists = false;
        bool contains_pin1 = false;

        foreach(node n in nodes){
            if( n.LenPins == 2 && n.ContainsAllPins(pin1, pin2) ){
                node_exists = true;
                break;
            }
            
            if( n.ContainsPin(pin1) ){
                contains_pin1 = true;
            }
        }

        if (!node_exists){
            string id_con = nextId() + "_node";
            node nnode;

            if( pin1.isSupply || contains_pin1 )
                nnode = new node(id_con, pin1, pin2);
            else
                nnode = new node(id_con, pin2, pin1);
            nodes.Add( nnode );
        }

        sortNodes();
    }

    // Remove all nodes that belogs an specific component.
    public void removeNodebyComponent(GameObject component){
        int i;
        for(i = 0; i<nodes.Count; i++){
            if( nodes[i].LenPins == 2 && nodes[i].BelongsToComponent(component) ){
                nodes.RemoveAt(i);
            }
        }
    }

    // Retrives the next node.
    // The component of last pin of current node should the same of the component of the first pin of next node.
    public node nextNode(node nd){
        foreach(node n in nodes){
            if( nd.node_id != n.node_id && n.BelongsToComponent(nd.pins[1].component) ){
                n.swapPins(nd.pins[1].component);
                return n;
            }
        }
        return null;
    }

    // Find and returns the supply node (+ pin battery).
    public node supplyNode(){
        foreach(node n in nodes){
            if(n.isSupply)
                return n;
        }
        return null;
    }

    // Find and returns the ground node (- pin battery).
    public node groundNode(){
        foreach(node n in nodes){
            if(n.isGround)
                return n;
        }
        return null;
    }

    // If nodes count are equals than components count, the circuit is closed.
    public bool isClosedCircuit(){
        return nodes.Count == components.Count;
    }
    

    void Update(){
        
        node actual_node = supplyNode();
        node ground_node = groundNode();
        adapter adap;

        // The circuit should have supply and ground nodes, and should be closed.
        if( !(actual_node is null) && !(ground_node is null) && isClosedCircuit() ){
            
            // Compute the current in series circuit
            circuit_current = 0.0f;
            foreach(GameObject comp in components){
                adap = comp.GetComponent<adapter>();
                circuit_current += adap.getLoadCurrent();
            }
            
            // Set circuit current for each component
            foreach(GameObject comp in components){
                adap = comp.GetComponent<adapter>();
                adap.setCircuitCurrent(circuit_current);
            }
            
            // Fisrt node (supply)
            float? voltage_in = 0.0f;
            adap = actual_node.getComponentByPin(actual_node.pins[0]).GetComponent<adapter>();
            adap.setInputVoltage(voltage_in);
            voltage_in = adap.getOutputVoltage();

            //Set voltaje on each component of series circuit
            for(int i = 0; i<nodes.Count; i++){

                adap = actual_node.getComponentByPin(actual_node.pins[1]).GetComponent<adapter>();
                adap.setInputVoltage(voltage_in, actual_node.pins[1].pin_id );
                voltage_in = adap.getOutputVoltage();

                actual_node = nextNode(actual_node);

                if (actual_node is null)
                    break;
            }

        }
        else{
            // If circuit is open, set input voltage as 0.0V for all components
            foreach(node n in nodes){
                adap = n.getComponentByPin(n.pins[0]).GetComponent<adapter>();
                adap.setInputVoltage(null);
            }
        }

    }
}
