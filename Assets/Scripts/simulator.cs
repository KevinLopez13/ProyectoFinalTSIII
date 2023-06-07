using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simulator : MonoBehaviour
{
    /*
    Class .....
    */
    List<GameObject> components = new List<GameObject>();
    List<node> nodes = new List<node>();
    private int nodes_cnt = 0;

    public float circuit_current = 0.0f;

    private string nextId(){
        return (nodes_cnt++).ToString();
    }

    public void addComponent(GameObject component){
        components.Add(component);
    }

    public void removeComponent(GameObject component){
        components.Remove(component);
        // Remove Node
    }

    public void sortNodes(){
        nodes.Sort((n1, n2) => n2.isSupply.CompareTo(n1.isSupply));
    }

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

    public node nextNode(node nd){
        foreach(node n in nodes){
            // Debug.LogWarning("Actual node: "+ nd + " " + (nd.node_id != n.node_id) + " " + n + ">> contains? " + (n.BelongsToComponent(nd.pins[1].component)));
            if( nd.node_id != n.node_id && n.BelongsToComponent(nd.pins[1].component) ){
                n.swapPins(nd.pins[1].component);
                return n;
            }
        }
        return null;
    }

    public node supplyNode(){
        foreach(node n in nodes){
            if(n.isSupply)
                return n;
        }
        return null;
    }

    public node groundNode(){
        foreach(node n in nodes){
            if(n.isGround)
                return n;
        }
        return null;
    }

    void Start(){

    }
    
    void Update(){
        
        node actual_node = supplyNode(); // node that contains the battery pin
        node ground_node = groundNode();
        adapter adap;

        if( !(actual_node is null) && !(ground_node is null) ){
            
            // Compute the current in series circuit
            circuit_current = 0.0f;
            foreach(GameObject comp in components){
                adap = comp.GetComponent<adapter>();
                circuit_current += adap.getLoadCurrent();
            }
            // Debug.LogWarning("Current: " + circuit_current.ToString());

            // Set circuit current for each component
            foreach(GameObject comp in components){
                adap = comp.GetComponent<adapter>();
                adap.setCircuitCurrent(circuit_current);
            }
            
            float voltage_in = 0.0f;
            adap = actual_node.getComponentByPin(actual_node.pins[0]).GetComponent<adapter>();
            adap.setInputVoltage(voltage_in);
            Debug.LogWarning( actual_node.pins[0].component.name + " Component 1: " + actual_node.pins[0] + " involtage: " + voltage_in );
            voltage_in = adap.getOutputVoltage();
            Debug.LogWarning( actual_node.pins[0].component.name + " Component 1: " + actual_node.pins[0] + " outvoltage: " + voltage_in );

            //Set voltaje on each component of series circuit
            for(int i = 0; i<nodes.Count; i++){
                // adapter adap = actual_node.getComponentByPin(actual_node.pins[0]).GetComponent<adapter>();
                // adap.setInputVoltage(voltage_in);
                // Debug.LogWarning( actual_node.pins[0].component.name + " Component 1: " + actual_node.pins[0] + " involtage: " + voltage_in );
                // voltage_in = adap.getOutputVoltage();
                // Debug.LogWarning( actual_node.pins[0].component.name + " Component 1: " + actual_node.pins[0] + " outvoltage: " + voltage_in );

                adap = actual_node.getComponentByPin(actual_node.pins[1]).GetComponent<adapter>();
                adap.setInputVoltage(voltage_in);
                Debug.LogWarning( actual_node.pins[1].component.name + " Component 2: " + actual_node.pins[1] + " involtage: " + voltage_in );
                voltage_in = adap.getOutputVoltage();
                Debug.LogWarning( actual_node.pins[1].component.name + " Component 2: " + actual_node.pins[1] + " outvoltage: " + voltage_in );

                actual_node = nextNode(actual_node);

                // foreach(node n in nodes){
                //     Debug.LogWarning("Node: " + n.ToString());
                // }

                if (actual_node is null)
                    break;
            }
        }

    }
}
